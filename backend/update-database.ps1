#!/usr/bin/env pwsh

# Caminho para os projetos
$AuthProject = "modules/Nexus.Auth/src/Nexus.Auth.Infra"
$AuthProjectStartup = "modules/Nexus.Auth/src/Nexus.Auth.Api/Nexus.Auth.Api.csproj"
$CadastroProject = "modules/Nexus.Cadastro/src/Nexus.Cadastro.Infra"
$CadastroProjectStartup = "modules/Nexus.Cadastro/src/Nexus.Cadastro.Api/Nexus.Cadastro.Api.csproj"

# Função para aplicar migrações
function UpdateDatabase($projectPath, $startupProject) {
    Write-Host "Aplicando migrações para o projeto $projectPath..."
    dotnet ef database update --project $projectPath --startup-project $startupProject
}

# Aplica as migrações para o projeto de autenticação
Write-Host "Atualizando banco de dados para o projeto de autenticação..."
UpdateDatabase $AuthProject $AuthProjectStartup

# Aplica as migrações para o projeto de cadastro
Write-Host "Atualizando banco de dados para o projeto de cadastro..."
UpdateDatabase $CadastroProject $CadastroProjectStartup

Write-Host "Processo de atualização do banco de dados concluído!"