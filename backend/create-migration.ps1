#!/usr/bin/env pwsh

# Nome da migração e projeto
param (
    [string]$MigrationName,
    [string]$Project
)

# Verifica se o nome da migração foi fornecido
if (-not $MigrationName) {
    Write-Host "Uso: .\create-migration.ps1 -MigrationName <nome-da-migracao> [-Project <Auth|Cadastro>]"
    exit 1
}

# Caminho para os projetos
$AuthProject = "modules/Nexus.Auth/src/Nexus.Auth.Infra"
$AuthProjectStartup = "modules/Nexus.Auth/src/Nexus.Auth.Api/Nexus.Auth.Api.csproj"
$CadastroProject = "modules/Nexus.Cadastro/src/Nexus.Cadastro.Infra"
$CadastroProjectStartup = "modules/Nexus.Cadastro/src/Nexus.Cadastro.Api/Nexus.Cadastro.Api.csproj"

# Função para criar e aplicar migrações
function CreateAndApplyMigration($projectPath, $migrationName, $startupProject) {
    $migrationResult = dotnet ef migrations add $migrationName --project $projectPath --startup-project $startupProject 2>&1

    if ($migrationResult -match "No changes were found") {
        Write-Host "Nenhuma alteração encontrada para o projeto $projectPath. Nenhuma migração criada."
    } elseif ($migrationResult -match "The name '(.+)' is already used") {
        Write-Host "Já existe uma migração com o nome '$migrationName' no projeto $projectPath."
    } else {
        Write-Host "Aplicando migrações para o projeto $projectPath..."
        dotnet ef database update --project $projectPath --startup-project $startupProject
    }
}

# Verifica qual projeto foi especificado
switch ($Project) {
    "Auth" {
        Write-Host "Criando migração para o projeto de autenticação..."
        CreateAndApplyMigration $AuthProject $MigrationName $AuthProjectStartup
    }
    "Cadastro" {
        Write-Host "Criando migração para o projeto de cadastro..."
        CreateAndApplyMigration $CadastroProject $MigrationName $CadastroProjectStartup
    }
    default {
        Write-Host "Projeto inválido ou não especificado. Use 'Auth' ou 'Cadastro'."
        exit 1
    }
}

Write-Host "Processo de migração concluído!"