import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.*;

public class TP04 extends JFrame implements ActionListener {

    JTextField txtPesquisa = new JTextField(20);
    JButton btnPesquisar = new JButton("Pesquisar");

    JTextField txtNome = new JTextField(20);
    JTextField txtSal = new JTextField(20);
    JTextField txtCargo = new JTextField(20);

    JButton btnAnt = new JButton("Anterior");
    JButton btnProx = new JButton("Próximo");

    Connection con;
    Statement st;
    ResultSet rs;

    public TP04() {

        super("TRABALHO PRATICO 04");

        // Look and Feel do Windows
        try {
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        } catch (Exception e) {}

        setLayout(null);
        setSize(400, 260);
        setLocationRelativeTo(null);

        // ----- CAMPO DE PESQUISA -----
        JLabel lblPesqNome = new JLabel("Nome:");
        lblPesqNome.setBounds(20, 20, 80, 25);
        txtPesquisa.setBounds(80, 20, 200, 25);
        btnPesquisar.setBounds(290, 20, 90, 25);

        add(lblPesqNome);
        add(txtPesquisa);
        add(btnPesquisar);

        // ----- CAMPOS DE RESULTADO -----
        JLabel lb1 = new JLabel("Nome:");
        JLabel lb2 = new JLabel("Salário:");
        JLabel lb3 = new JLabel("Cargo:");

        lb1.setBounds(20, 65, 100, 25);
        lb2.setBounds(20, 95, 100, 25);
        lb3.setBounds(20, 125, 100, 25);

        txtNome.setBounds(120, 65, 200, 25);
        txtSal.setBounds(120, 95, 200, 25);
        txtCargo.setBounds(120, 125, 200, 25);

        txtNome.setEditable(false);
        txtSal.setEditable(false);
        txtCargo.setEditable(false);

        add(lb1); add(txtNome);
        add(lb2); add(txtSal);
        add(lb3); add(txtCargo);

        // ----- BOTÕES DE NAVEGAÇÃO -----
        btnAnt.setBounds(20, 170, 150, 30);
        btnProx.setBounds(190, 170, 150, 30);

        add(btnAnt);
        add(btnProx);

        btnAnt.addActionListener(this);
        btnProx.addActionListener(this);
        btnPesquisar.addActionListener(this);

        btnAnt.setEnabled(false);
        btnProx.setEnabled(false);

        // ----- ABRE CONEXÃO -----
        conectar();

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setVisible(true);
    }

    // ===============================
    // CONEXÃO
    // ===============================
    public void conectar() {
        try {
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");

            String url =
                    "jdbc:sqlserver://127.0.0.1\\;databaseName=TP04;integratedSecurity=true;";

            con = DriverManager.getConnection(url);
            st = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE,
                    ResultSet.CONCUR_READ_ONLY);

        } catch (Exception e) {
            JOptionPane.showMessageDialog(this, "Erro de conexão: " + e.getMessage());
        }
    }

    // ===============================
    // AÇÕES
    // ===============================
    @Override
    public void actionPerformed(ActionEvent e) {

        if (e.getSource() == btnPesquisar) {
            pesquisar();
        }

        if (e.getSource() == btnAnt) {
            anterior();
        }

        if (e.getSource() == btnProx) {
            proximo();
        }
    }

    // ===============================
    // PESQUISA
    // ===============================
    public void pesquisar() {
        try {
            String nome = txtPesquisa.getText().trim();

            if (nome.isEmpty()) {
                JOptionPane.showMessageDialog(this, "Digite um nome para pesquisar!");
                return;
            }

            String sql =
                    "SELECT f.nome_func, f.sal_func, c.ds_cargo " +
                            "FROM tbfuncs f INNER JOIN tbcargos c ON f.cod_cargo = c.cd_cargo " +
                            "WHERE f.nome_func LIKE '%" + nome + "%' " +
                            "ORDER BY f.nome_func";

            rs = st.executeQuery(sql);

            if (rs.next()) {
                mostrarRegistro();
                btnProx.setEnabled(true);
                btnAnt.setEnabled(false);
            } else {
                JOptionPane.showMessageDialog(this, "Nenhum registro encontrado.");
                limparCampos();
                btnProx.setEnabled(false);
                btnAnt.setEnabled(false);
            }

        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Erro: " + ex.getMessage());
        }
    }

    // ===============================
    // NAVEGAÇÃO
    // ===============================
    public void proximo() {
        try {
            if (rs.next()) {
                mostrarRegistro();
                btnAnt.setEnabled(true);

                if (rs.isLast()) {
                    btnProx.setEnabled(false);
                }
            }
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Erro ao navegar: " + ex.getMessage());
        }
    }

    public void anterior() {
        try {
            if (rs.previous()) {
                mostrarRegistro();
                btnProx.setEnabled(true);

                if (rs.isFirst()) {
                    btnAnt.setEnabled(false);
                }
            }
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(this, "Erro ao navegar: " + ex.getMessage());
        }
    }

    // ===============================
    // MOSTRAR REGISTRO
    // ===============================
    public void mostrarRegistro() throws SQLException {
        txtNome.setText(rs.getString(1));
        txtSal.setText("" + rs.getDouble(2));
        txtCargo.setText(rs.getString(3));
    }

    // ===============================
    // LIMPAR CAMPOS
    // ===============================
    public void limparCampos() {
        txtNome.setText("");
        txtSal.setText("");
        txtCargo.setText("");
    }

    // ===============================
    // MAIN
    // ===============================
    public static void main(String[] args) {
        new TP04();
    }
}
