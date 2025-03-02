import { REGISTER_PREFIX_PATH } from "@/constants/route.constant";
import {
    NAV_ITEM_TYPE_TITLE,
    NAV_ITEM_TYPE_ITEM,
    NAV_ITEM_TYPE_COLLAPSE
} from "@/constants/navigation.constant";
import { ADMIN, USER } from '@/constants/roles.constant'
import type { NavigationTree } from '@/@types/navigation'

const registerNavigationConfig: NavigationTree[] = [
    {
        key: 'register',
        path: '',
        title: 'Cadastro',
        translateKey: 'nav.register',
        icon: 'register',
        type: NAV_ITEM_TYPE_TITLE,
        authority: [],
        meta: {
            horizontalMenu: {
                layout: 'columns',
                columns: 4,
            },
        },
        subMenu: [
            {
                key: 'register.customers',
                path: '',
                title: 'Clientes',
                translateKey: 'nav.registerCustomers.customers',
                icon: 'customers',
                type: NAV_ITEM_TYPE_COLLAPSE,
                authority: [],
                meta: {
                    description: {
                        translateKey: 'nav.registerCustomers.CustomersDesc',
                        label: 'Gerenciamento de clientes',
                    },
                },
                subMenu: [
                    {
                        key: 'register.customers.list',
                        path: `${REGISTER_PREFIX_PATH}/customers/list`,
                        title: 'Listar',
                        translateKey: 'nav.registerCustomers.list',
                        icon: 'customerList',
                        type: NAV_ITEM_TYPE_ITEM,
                        authority: [],
                        meta: {
                            description: {
                                translateKey: 'nav.registerCustomers.listDesc',
                                label: 'Listar clientes',
                            },
                        },
                        subMenu: [],
                    },
                    {
                        key: 'register.customers.create',
                        path: `${REGISTER_PREFIX_PATH}/customers/create`,
                        title: 'Criar',
                        translateKey: 'nav.registerCustomers.create',
                        icon: 'customerCreate',
                        type: NAV_ITEM_TYPE_ITEM,
                        authority: [],
                        meta: {
                            description: {
                                translateKey: 'nav.registerCustomers.createDesc',
                                label: 'Cadastrar cliente',
                            },
                        },
                        subMenu: [],
                    }
                ]
            },
        ],
    },
]

export default registerNavigationConfig