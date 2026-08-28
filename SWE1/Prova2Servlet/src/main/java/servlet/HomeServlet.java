package servlet;

import java.io.IOException;
import java.sql.SQLException;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import dao.CustomerDAO;
import dao.OrderDAO;
import dao.SalesmanDAO;

@WebServlet("/home")
public class HomeServlet extends HttpServlet {
    private final SalesmanDAO salesmanDao = new SalesmanDAO();
    private final CustomerDAO customerDao = new CustomerDAO();
    private final OrderDAO salesOrderDao = new OrderDAO();

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            request.setAttribute("activePage", "home");
            request.setAttribute("salesmanCount", salesmanDao.count());
            request.setAttribute("customerCount", customerDao.count());
            request.setAttribute("orderCount", salesOrderDao.count());
            request.getRequestDispatcher("/WEB-INF/views/home.jsp").forward(request, response);
        } catch (SQLException exception) {
            throw new ServletException(exception);
        }
    }
}
