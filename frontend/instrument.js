// Import with `import * as Sentry from "@sentry/node"` if you are using ESM
import { init } from "@sentry/node";

init({
    dsn: "https://5e3693b715cd7e37835c72a7a58a7e43@o4508848896999424.ingest.us.sentry.io/4508848897327105",
});

app.use(Sentry.Handlers.requestHandler());