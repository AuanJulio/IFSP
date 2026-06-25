package dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import model.Salesman;

public class SalesmanDAO {
	
	public List<Salesman> findAll() throws SQLException {
		String sql = "SELECT salesman_id, name, city, commission FROM salesman ORDER BY salesman_id";
		List<Salesman> salesmen = new ArrayList<>();

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql);
				ResultSet resultSet = statement.executeQuery()) {
			while (resultSet.next()) {
				salesmen.add(map(resultSet));
			}
		}

		return salesmen;
	}

	public Salesman findById(int id) throws SQLException {
		String sql = "SELECT salesman_id, name, city, commission FROM salesman WHERE salesman_id = ?";

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql)) {
			statement.setInt(1, id);

			try (ResultSet resultSet = statement.executeQuery()) {
				return resultSet.next() ? map(resultSet) : null;
			}
		}
	}

	public void insert(Salesman salesman) throws SQLException {
		String sql = "INSERT INTO salesman (salesman_id, name, city, commission) VALUES (?, ?, ?, ?)";

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql)) {
			statement.setInt(1, salesman.getSalesmanId());
			statement.setString(2, salesman.getName());
			statement.setString(3, salesman.getCity());
			statement.setBigDecimal(4, salesman.getCommission());
			statement.executeUpdate();
		}
	}

	public void update(Salesman salesman) throws SQLException {
		String sql = "UPDATE salesman SET name = ?, city = ?, commission = ? WHERE salesman_id = ?";

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql)) {
			statement.setString(1, salesman.getName());
			statement.setString(2, salesman.getCity());
			statement.setBigDecimal(3, salesman.getCommission());
			statement.setInt(4, salesman.getSalesmanId());
			statement.executeUpdate();
		}
	}

	public void delete(int id) throws SQLException {
		String sql = "DELETE FROM salesman WHERE salesman_id = ?";

		try (Connection connection = Database.getConnection();
				PreparedStatement statement = connection.prepareStatement(sql)) {
			statement.setInt(1, id);
			statement.executeUpdate();
		}
	}

	public long count() throws SQLException {
		try (Connection connection = Database.getConnection();
				Statement statement = connection.createStatement();
				ResultSet resultSet = statement.executeQuery("SELECT COUNT(*) FROM salesman")) {
			resultSet.next();
			return resultSet.getLong(1);
		}
	}

	private Salesman map(ResultSet resultSet) throws SQLException {
		Salesman salesman = new Salesman();
		salesman.setSalesmanId(resultSet.getInt("salesman_id"));
		salesman.setName(resultSet.getString("name"));
		salesman.setCity(resultSet.getString("city"));
		salesman.setCommission(resultSet.getBigDecimal("commission"));
		return salesman;
	}
	
}
