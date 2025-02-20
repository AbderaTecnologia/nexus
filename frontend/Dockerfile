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

# Use uma imagem base do Nginx para servir o aplicativo
FROM nginx:alpine

# Copie os arquivos construídos para o diretório padrão do Nginx
COPY --from=build /app/build /usr/share/nginx/html

# Copie o arquivo de configuração do servidor
COPY ./nginx/nginx.conf /etc/nginx

ENTRYPOINT ["nginx", "-g", "daemon off;"]