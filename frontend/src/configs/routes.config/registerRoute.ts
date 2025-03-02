import { lazy } from "react";
import type { Routes } from "@/@types/routes";

const registerRoute: Routes = [
    {
        key: "register",
        path: "/register/customers",
        component: lazy(() => import("@/views/modules/register/customers/List/ListCustomers")),
        authority: [],
    },
];

export default registerRoute;