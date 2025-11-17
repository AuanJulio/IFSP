package EX02;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

public class FormV2 extends JFrame implements ActionListener {

    private JTextField txtNumero = new JTextField();
    private JTextField txtNome   = new JTextField();
    private JTextField txtIdade  = new JTextField();

    private JComboBox<String> cbSexo = new JComboBox<>(new String[]{"M", "F"});

    private JButton btnOk = new JButton("OK");
    private JButton btnMostrar = new JButton("Mostrar");

    private Pessoa umaPessoa = new Pessoa();

    public FormV2() {

        super("Form Pessoa - Versão 02");
        try {
            UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
        } catch (Exception e) {}

        setSize(320, 240);
        setLayout(null);
        setLocationRelativeTo(null);

        JLabel lblNumero = new JLabel("Número:");
        JLabel lblNome   = new JLabel("Nome:");
        JLabel lblSexo   = new JLabel("Sexo:");
        JLabel lblIdade  = new JLabel("Idade:");

        lblNumero.setBounds(20, 20, 80, 25);
        txtNumero.setBounds(120, 20, 150, 25);
        txtNumero.setEditable(false);

        lblNome.setBounds(20, 55, 80, 25);
        txtNome.setBounds(120, 55, 150, 25);

        lblSexo.setBounds(20, 90, 80, 25);
        cbSexo.setBounds(120, 90, 150, 25);

        lblIdade.setBounds(20, 125, 80, 25);
        txtIdade.setBounds(120, 125, 150, 25);

        btnOk.setBounds(40, 165, 100, 30);
        btnMostrar.setBounds(160, 165, 100, 30);

        add(lblNumero); add(txtNumero);
        add(lblNome); add(txtNome);
        add(lblSexo); add(cbSexo);
        add(lblIdade); add(txtIdade);
        add(btnOk); add(btnMostrar);

        btnOk.addActionListener(this);
        btnMostrar.addActionListener(this);

        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e) { System.exit(0); }
        });

        setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {

        if (e.getSource() == btnOk) {
            try {
                String nome = txtNome.getText().trim();
                String idadeTxt = txtIdade.getText().trim();

                if (nome.isEmpty() || idadeTxt.isEmpty()) {
                    throw new Exception("Todos os campos são obrigatórios.");
                }

                char sexo = cbSexo.getSelectedItem().toString().charAt(0);
                int idade = Integer.parseInt(idadeTxt);

                umaPessoa.setNome(nome);
                umaPessoa.setSexo(sexo);
                umaPessoa.setIdade(idade);
                umaPessoa.setKp();

                txtNumero.setText(String.valueOf(Pessoa.getKp()));

                JOptionPane.showMessageDialog(this, "Dados gravados com sucesso!");

            } catch (Exception ex) {
                JOptionPane.showMessageDialog(this, ex.getMessage(), "Erro", JOptionPane.ERROR_MESSAGE);
            }
        }

        if (e.getSource() == btnMostrar) {
            String msg =
                    "Número: " + Pessoa.getKp() +
                            "\nNome: "   + umaPessoa.getNome() +
                            "\nSexo: "   + umaPessoa.getSexo() +
                            "\nIdade: "  + umaPessoa.getIdade();

            JOptionPane.showMessageDialog(this, msg, "Dados da Pessoa", JOptionPane.INFORMATION_MESSAGE);
        }
    }

    public static void main(String[] args) {
        new FormV2();
    }
}
