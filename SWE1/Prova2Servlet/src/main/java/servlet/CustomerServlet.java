package servlet;

import static servlet.ServletUtil.databaseMessage;
import static servlet.ServletUtil.integer;
import static servlet.ServletUtil.text;

import java.io.IOException;
import java.sql.SQLException;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import dao.CustomerDAO;
import dao.SalesmanDAO;
import model.Customer;

@WebServlet("/customers")
public class CustomerServlet extends HttpServlet {
    private final CustomerDAO customerDao = new CustomerDAO();
    private final SalesmanDAO salesmanDao = new SalesmanDAO();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String action = request.getParameter("action");

        try {
            if ("new".equals(action)) {
                showForm(request, response, new Customer(), false);
            } else if ("edit".equals(action)) {
                Customer customer = customerDao.findById(integer(request, "id", "Codigo", 1, 99999));
                if (customer == null) {
                    list(request, response, "Cliente nao encontrado.", null);
                    return;
                }
                showForm(request, response, customer, true);
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
                customerDao.delete(integer(request, "id", "Codigo", 1, 99999));
                response.sendRedirect(request.getContextPath() + "/customers?deleted=1");
                return;
            }

            Customer customer = parse(request);
            boolean editing = Boolean.parseBoolean(request.getParameter("editing"));

            if (editing) {
                customerDao.update(customer);
            } else {
                customerDao.insert(customer);
            }

            response.sendRedirect(request.getContextPath() + "/customers?saved=1");
        } catch (IllegalArgumentException exception) {
            request.setAttribute("error", exception.getMessage());
            showForm(request, response, parseLenient(request), Boolean.parseBoolean(request.getParameter("editing")));
        } catch (SQLException exception) {
            if ("delete".equals(action)) {
                list(request, response, databaseMessage(exception, "excluir o cliente"), null);
            } else {
                request.setAttribute("error", databaseMessage(exception, "salvar o cliente"));
                showForm(request, response, parseLenient(request), Boolean.parseBoolean(request.getParameter("editing")));
            }
        }
    }

    private void list(HttpServletRequest request, HttpServletResponse response, String error, String success)
            throws ServletException, IOException {
        try {
            request.setAttribute("activePage", "customers");
            request.setAttribute("customers", customerDao.findAll());
            request.setAttribute("error", error);
            request.setAttribute("success", success);
            request.getRequestDispatcher("/WEB-INF/views/customers/list.jsp").forward(request, response);
        } catch (SQLException exception) {
            throw new ServletException(exception);
        }
    }

    private void showForm(HttpServletRequest request, HttpServletResponse response, Customer customer, boolean editing)
            throws ServletException, IOException {
        try {
            request.setAttribute("activePage", "customers");
            request.setAttribute("customer", customer);
            request.setAttribute("salesmen", salesmanDao.findAll());
            request.setAttribute("editing", editing);
            request.getRequestDispatcher("/WEB-INF/views/customers/form.jsp").forward(request, response);
        } catch (SQLException exception) {
            throw new ServletException(exception);
        }
    }

    private Customer parse(HttpServletRequest request) {
        return new Customer(
                integer(request, "customerId", "Codigo", 1, 99999),
                text(request, "custName", "Nome", 30),
                text(request, "city", "Cidade", 15),
                integer(request, "grade", "Nota", 0, 999),
                integer(request, "salesmanId", "Vendedor", 1, 99999)
        );
    }

    private Customer parseLenient(HttpServletRequest request) {
        Customer customer = new Customer();
        try {
            customer.setCustomerId(Integer.parseInt(request.getParameter("customerId")));
        } catch (RuntimeException ignored) {
            customer.setCustomerId(0);
        }
        customer.setCustName(request.getParameter("custName"));
        customer.setCity(request.getParameter("city"));
        try {
            customer.setGrade(Integer.parseInt(request.getParameter("grade")));
        } catch (RuntimeException ignored) {
            customer.setGrade(0);
        }
        try {
            customer.setSalesmanId(Integer.parseInt(request.getParameter("salesmanId")));
        } catch (RuntimeException ignored) {
            customer.setSalesmanId(0);
        }
        return customer;
    }

    private String successMessage(HttpServletRequest request) {
        if ("1".equals(request.getParameter("saved"))) {
            return "Cliente salvo com sucesso.";
        }
        if ("1".equals(request.getParameter("deleted"))) {
            return "Cliente excluido com sucesso.";
        }
        return null;
    }
}