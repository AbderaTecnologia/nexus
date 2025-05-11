import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import './index.css'
import * as Sentry from '@sentry/react';

Sentry.init({
    dsn: 'https://5e3693b715cd7e37835c72a7a58a7e43@o4508848896999424.ingest.us.sentry.io/4508848897327105',
    tracesSampleRate: 1.0,
});

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <Sentry.ErrorBoundary fallback={<p>Algo deu errado.</p>}>
            <App />
        </Sentry.ErrorBoundary>
    </React.StrictMode>,
)
