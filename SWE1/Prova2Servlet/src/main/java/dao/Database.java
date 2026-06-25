package dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class Database {

	private static final String URL = "jdbc:mysql://localhost:3306/swii5";

	private static final String USER = "root";

	private static final String PASSWORD = "admin";

	private Database() {
	}

	public static Connection getConnection() throws SQLException {

		try {

			Class.forName("com.mysql.cj.jdbc.Driver");

		} catch (ClassNotFoundException e) {

			throw new SQLException("Driver MySQL não encontrado", e);
		}

		return DriverManager.getConnection(URL, USER, PASSWORD);
	}

}
