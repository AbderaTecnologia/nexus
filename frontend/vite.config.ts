import { sentryVitePlugin } from "@sentry/vite-plugin";
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path';
import dynamicImport from 'vite-plugin-dynamic-import'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react(), dynamicImport(), sentryVitePlugin({
    org: "alex-kav-rocha",
    project: "nexus-qn1qaa"
  })],
  assetsInclude: ['**/*.md'],
  resolve: {
    alias: {
      '@': path.join(__dirname, 'src'),
    },
  },
  server: {
    proxy: {
      '/api/auth': {
        target: 'http://localhost:5054',
        changeOrigin: true,
        secure: false
      },
      '/api/cadastro': {
        target: 'http://nexuscadastro.runasp.net',
        changeOrigin: true,
        secure: false
      }
    }
  },
  build: {
    outDir: 'build',
    sourcemap: true
  }
})