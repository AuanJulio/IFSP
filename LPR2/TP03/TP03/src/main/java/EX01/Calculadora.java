package EX01;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

public class Calculadora extends JFrame implements ActionListener {

    private JTextField display = new JTextField("0");
    private double valor1 = 0;
    private double valor2 = 0;
    private String operador = "";
    private boolean limpar = false;

    public Calculadora() {
        super("Calculadora");

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(300, 350);
        setLocationRelativeTo(null);

        setLayout(new BorderLayout(5, 5));

        display.setEditable(false);
        display.setHorizontalAlignment(SwingConstants.RIGHT);
        display.setBackground(Color.WHITE);
        display.setPreferredSize(new Dimension(0, 50));
        add(display, BorderLayout.NORTH);

        JPanel painel = new JPanel();
        painel.setLayout(new GridLayout(5, 4, 3, 3));

        String botoes[] = {
                "7","8","9","/",
                "4","5","6","*",
                "1","2","3","-",
                "0",".","=","+",
                "C","","",""
        };

        for (String txt : botoes) {
            if (txt.equals("")) {
                painel.add(new JLabel());
                continue;
            }
            JButton b = new JButton(txt);
            b.setFont(new Font("Arial", Font.BOLD, 18));
            b.addActionListener(this);
            painel.add(b);
        }

        add(painel, BorderLayout.CENTER);

        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        String cmd = e.getActionCommand();

        try {

            // Clear
            if (cmd.equals("C")) {
                display.setText("0");
                valor1 = valor2 = 0;
                operador = "";
                limpar = false;
                return;
            }

            if ("0123456789".contains(cmd)) {
                if (display.getText().equals("0") || limpar) {
                    display.setText(cmd);
                    limpar = false;
                } else {
                    display.setText(display.getText() + cmd);
                }
                return;
            }

            if (cmd.equals(".")) {
                if (!display.getText().contains(".")) {
                    display.setText(display.getText() + ".");
                }
                return;
            }

            if ("+-*/".contains(cmd)) {
                valor1 = Double.parseDouble(display.getText());
                operador = cmd;
                limpar = true;
                return;
            }

            if (cmd.equals("=")) {
                valor2 = Double.parseDouble(display.getText());
                double resultado = 0;

                switch (operador) {
                    case "+": resultado = valor1 + valor2; break;
                    case "-": resultado = valor1 - valor2; break;
                    case "*": resultado = valor1 * valor2; break;
                    case "/":
                        if (valor2 == 0) throw new ArithmeticException("Divisão por zero!");
                        resultado = valor1 / valor2;
                        break;
                }

                display.setText(String.valueOf(resultado));
                limpar = true;
            }

        } catch (NumberFormatException ex) {
            display.setText("Erro");
        } catch (ArithmeticException ex) {
            display.setText("Erro: " + ex.getMessage());
        } catch (Exception ex) {
            display.setText("Erro inesperado");
        }
    }

    public static void main(String[] args) {
        try {
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        } catch (Exception e) {}

        new Calculadora();
    }

}
