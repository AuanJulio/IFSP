package servlet;

import static servlet.ServletUtil.databaseMessage;
import static servlet.ServletUtil.decimal;
import static servlet.ServletUtil.integer;
import static servlet.ServletUtil.text;

import java.io.IOException;
import java.sql.SQLException;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import dao.SalesmanDAO;
import model.Salesman;

@WebServlet("/salesmen")
public class SalesmanServlet extends HttpServlet {
    private final SalesmanDAO salesmanDao = new SalesmanDAO();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String action = request.getParameter("action");

        try {
            if ("new".equals(action)) {
                showForm(request, response, new Salesman(), false);
            } else if ("edit".equals(action)) {
                Salesman salesman = salesmanDao.findById(integer(request, "id", "Codigo", 1, 99999));
                if (salesman == null) {
                    list(request, response, "Vendedor nao encontrado.", null);
                    return;
                }
                showForm(request, response, salesman, true);
            } else {
                list(request, response, null, successMessage(request));
            }
        } catch (SQLException exception) {
            throw new ServletException(exception);
        } catch (IllegalArgumentException exception) {
            list(request, response, exception.getMessage(), null);
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.setCharacterEncoding("UTF-8");
        String action = request.getParameter("action");

        try {
            if ("delete".equals(action)) {
                salesmanDao.delete(integer(request, "id", "Codigo", 1, 99999));
                response.sendRedirect(request.getContextPath() + "/salesmen?deleted=1");
                return;
            }

            Salesman salesman = parse(request);
            boolean editing = Boolean.parseBoolean(request.getParameter("editing"));

            if (editing) {
                salesmanDao.update(salesman);
            } else {
                salesmanDao.insert(salesman);
            }

            response.sendRedirect(request.getContextPath() + "/salesmen?saved=1");
        } catch (IllegalArgumentException exception) {
            Salesman salesman = parseLenient(request);
            request.setAttribute("error", exception.getMessage());
            showForm(request, response, salesman, Boolean.parseBoolean(request.getParameter("editing")));
        } catch (SQLException exception) {
            if ("delete".equals(action)) {
                list(request, response, databaseMessage(exception, "excluir o vendedor"), null);
            } else {
                Salesman salesman = parseLenient(request);
                request.setAttribute("error", databaseMessage(exception, "salvar o vendedor"));
                showForm(request, response, salesman, Boolean.parseBoolean(request.getParameter("editing")));
            }
        }
    }

    private void list(HttpServletRequest request, HttpServletResponse response, String error, String success)
            throws ServletException, IOException {
        try {
            request.setAttribute("activePage", "salesmen");
            request.setAttribute("salesmen", salesmanDao.findAll());
            request.setAttribute("error", error);
            request.setAttribute("success", success);
            request.getRequestDispatcher("/WEB-INF/views/salesmen/list.jsp").forward(request, response);
        } catch (SQLException exception) {
            throw new ServletException(exception);
        }
    }

    private void showForm(HttpServletRequest request, HttpServletResponse response, Salesman salesman, boolean editing)
            throws ServletException, IOException {
        request.setAttribute("activePage", "salesmen");
        request.setAttribute("salesman", salesman);
        request.setAttribute("editing", editing);
        request.getRequestDispatcher("/WEB-INF/views/salesmen/form.jsp").forward(request, response);
    }

    private Salesman parse(HttpServletRequest request) {
        return new Salesman(
                integer(request, "salesmanId", "Codigo", 1, 99999),
                text(request, "name", "Nome", 30),
                text(request, "city", "Cidade", 15),
                decimal(request, "commission", "Comissao")
        );
    }

    private Salesman parseLenient(HttpServletRequest request) {
        Salesman salesman = new Salesman();
        try {
            salesman.setSalesmanId(Integer.parseInt(request.getParameter("salesmanId")));
        } catch (RuntimeException ignored) {
            salesman.setSalesmanId(0);
        }
        salesman.setName(request.getParameter("name"));
        salesman.setCity(request.getParameter("city"));
        try {
            salesman.setCommission(decimal(request, "commission", "Comissao"));
        } catch (RuntimeException ignored) {
            salesman.setCommission(null);
        }
        return salesman;
    }

    private String successMessage(HttpServletRequest request) {
        if ("1".equals(request.getParameter("saved"))) {
            return "Vendedor salvo com sucesso.";
        }
        if ("1".equals(request.getParameter("deleted"))) {
            return "Vendedor excluido com sucesso.";
        }
        return null;
    }
}
