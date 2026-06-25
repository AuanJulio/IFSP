package dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import model.Customer;

public class CustomerDAO {

	public List<Customer> findAll() throws SQLException {
		String sql = "SELECT c.customer_id, c.cust_name, c.city, c.grade, c.salesman_id, s.name AS salesman_name "
				+ "FROM customer c INNER JOIN salesman s ON s.salesman_id = c.salesman_id " + "ORDER BY c.customer_id";
		List<Customer> customers = new ArrayList<>();

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql);
				ResultSet resultSet = statement.executeQuery()) {
			while (resultSet.next()) {
				customers.add(map(resultSet));
			}
		}

		return customers;
	}

	public Customer findById(int id) throws SQLException {
		String sql = "SELECT c.customer_id, c.cust_name, c.city, c.grade, c.salesman_id, s.name AS salesman_name "
				+ "FROM customer c INNER JOIN salesman s ON s.salesman_id = c.salesman_id " + "WHERE c.customer_id = ?";

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql)) {
			statement.setInt(1, id);

			try (ResultSet resultSet = statement.executeQuery()) {
				return resultSet.next() ? map(resultSet) : null;
			}
		}
	}

	public void insert(Customer customer) throws SQLException {
		String sql = "INSERT INTO customer (customer_id, cust_name, city, grade, salesman_id) VALUES (?, ?, ?, ?, ?)";

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql)) {
			statement.setInt(1, customer.getCustomerId());
			statement.setString(2, customer.getCustName());
			statement.setString(3, customer.getCity());
			statement.setInt(4, customer.getGrade());
			statement.setInt(5, customer.getSalesmanId());
			statement.executeUpdate();
		}
	}

	public void update(Customer customer) throws SQLException {
		String sql = "UPDATE customer SET cust_name = ?, city = ?, grade = ?, salesman_id = ? WHERE customer_id = ?";

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql)) {
			statement.setString(1, customer.getCustName());
			statement.setString(2, customer.getCity());
			statement.setInt(3, customer.getGrade());
			statement.setInt(4, customer.getSalesmanId());
			statement.setInt(5, customer.getCustomerId());
			statement.executeUpdate();
		}
	}

	public void delete(int id) throws SQLException {
		String sql = "DELETE FROM customer WHERE customer_id = ?";

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql)) {
			statement.setInt(1, id);
			statement.executeUpdate();
		}
	}

	public long count() throws SQLException {
		try (Connection connection = Database.getConnection();
				Statement statement = connection.createStatement();
				ResultSet resultSet = statement.executeQuery("SELECT COUNT(*) FROM customer")) {
			resultSet.next();
			return resultSet.getLong(1);
		}
	}

	private Customer map(ResultSet resultSet) throws SQLException {
		Customer customer = new Customer();
		customer.setCustomerId(resultSet.getInt("customer_id"));
		customer.setCustName(resultSet.getString("cust_name"));
		customer.setCity(resultSet.getString("city"));
		customer.setGrade(resultSet.getInt("grade"));
		customer.setSalesmanId(resultSet.getInt("salesman_id"));
		customer.setSalesmanName(resultSet.getString("salesman_name"));
		return customer;
	}

}
