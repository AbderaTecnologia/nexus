# Use a imagem base do Node.js
FROM node:18-alpine AS build

# Defina o diretório de trabalho
WORKDIR /app

# Copie os arquivos package.json e package-lock.json
COPY package*.json ./

# Instale as dependências
RUN npm install

# Copie o restante dos arquivos do projeto
COPY . .

# Construa o projeto
RUN npm run build

# Use uma imagem base do Caddy para servir o aplicativo
FROM caddy:alpine

# Copie os arquivos construídos para o diretório padrão do Caddy
COPY --from=build /app/build /usr/share/caddy