import { lazy } from "react";
import type { Routes } from "@/@types/routes";

const registerRoute: Routes = [
    {
        key: "register.customers.list",
        path: "/register/customers/list",
        component: lazy(() => import("@/views/register/customers/List/ListCustomers")),
        authority: [],
    },
    {
        key: "register.customers.create",
        path: "/register/customers/create",
        component: lazy(() => import("@/views/register/customers/Create/CustomerCreate")),
        authority: [],
        meta: {
            header: {
                title: 'Novo cliente',
                description:
                    'Cadastre um novo cliente para o sistema.',
                contained: true,
            },
            footer: false,
        }
    },
];

export default registerRoute;