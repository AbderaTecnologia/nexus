import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path';
import dynamicImport from 'vite-plugin-dynamic-import'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react(), dynamicImport()],
  assetsInclude: ['**/*.md'],
  resolve: {
    alias: {
      '@': path.join(__dirname, 'src'),
    },
  },
  server: {
    proxy: {
      '/api/auth': {
        target: 'http://nexusapi.runasp.net',
        changeOrigin: true,
        secure: false
      },
      '/api/register': {
        target: 'http://localhost:5013',
        changeOrigin: true,
        secure: false
      },
      '/api/dashboard': {
        target: 'http://localhost:3000',
        changeOrigin: true,
        secure: false
      },
    }
  },
  build: {
    outDir: 'build',
    sourcemap: true
  }
})