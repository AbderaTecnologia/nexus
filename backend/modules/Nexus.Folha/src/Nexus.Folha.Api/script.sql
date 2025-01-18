CREATE TABLE Funcionario
(
    Id VARCHAR PRIMARY KEY,
    NomeCompleto VARCHAR,
    DataNascimento DATETIME NOT NULL,
    NomePai VARCHAR,
    NomeMae VARCHAR,
    Cep VARCHAR,
    Endereco VARCHAR,
    Cidade VARCHAR,
    UF VARCHAR,
    LocalNascimento VARCHAR,
    Telefone VARCHAR,
    NomeConjuge VARCHAR
);

INSERT INTO Funcionario values (
'1ae71318-fa78-428d-b4f6-436e6753f27c',
'Ricardo Negao',
DATE('now'),
'Paulinho Nunes',
'Maria Madelena',
'76815965',
'Rua das Beiras',
'Porto Velho',
'RO',
'Castanheirinha',
'69992157898',
''
);

INSERT INTO Funcionario values (
'39149796-dc68-4e4e-aa90-10edd145f85b',
'Paulo Moreno Luz',
DATE('now'),
'Paulinho Luz',
'Maria de Sá',
'76815965',
'Rua das Beiras',
'Porto Velho',
'RO',
'Castanheirinha',
'69992157898',
''
);