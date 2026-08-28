package servlet;

import java.math.BigDecimal;
import java.sql.SQLException;
import java.time.LocalDate;
import java.time.format.DateTimeParseException;

import javax.servlet.http.HttpServletRequest;

final class ServletUtil {
    private ServletUtil() {
    }

    static String text(HttpServletRequest request, String name, String label, int maxLength) {
        String value = request.getParameter(name);
        value = value == null ? "" : value.trim();

        if (value.isEmpty()) {
            throw new IllegalArgumentException(label + " obrigatorio.");
        }

        if (value.length() > maxLength) {
            throw new IllegalArgumentException(label + " deve ter no maximo " + maxLength + " caracteres.");
        }

        return value;
    }

    static int integer(HttpServletRequest request, String name, String label, int min, int max) {
        String value = request.getParameter(name);

        try {
            int number = Integer.parseInt(value == null ? "" : value.trim());
            if (number < min || number > max) {
                throw new IllegalArgumentException(label + " deve estar entre " + min + " e " + max + ".");
            }
            return number;
        } catch (NumberFormatException exception) {
            throw new IllegalArgumentException(label + " deve ser um numero inteiro.");
        }
    }

    static BigDecimal decimal(HttpServletRequest request, String name, String label) {
        String value = request.getParameter(name);
        value = value == null ? "" : value.trim().replace(',', '.');

        try {
            BigDecimal number = new BigDecimal(value);
            if (number.compareTo(BigDecimal.ZERO) < 0) {
                throw new IllegalArgumentException(label + " nao pode ser negativo.");
            }
            return number;
        } catch (NumberFormatException exception) {
            throw new IllegalArgumentException(label + " deve ser um valor decimal valido.");
        }
    }

    static LocalDate date(HttpServletRequest request, String name, String label) {
        String value = request.getParameter(name);

        try {
            return LocalDate.parse(value == null ? "" : value.trim());
        } catch (DateTimeParseException exception) {
            throw new IllegalArgumentException(label + " deve ser uma data valida.");
        }
    }

    static String databaseMessage(SQLException exception, String action) {
        String state = exception.getSQLState();
        if (state != null && state.startsWith("23")) {
            return "Nao foi possivel " + action + " porque existem registros relacionados ou dados duplicados.";
        }
        return "Nao foi possivel " + action + ". Verifique os dados e tente novamente.";
    }
}