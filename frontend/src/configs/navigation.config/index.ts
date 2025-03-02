import {
    NAV_ITEM_TYPE_TITLE,
    NAV_ITEM_TYPE_ITEM,
    NAV_ITEM_TYPE_COLLAPSE,
} from '@/constants/navigation.constant'

import type { NavigationTree } from '@/@types/navigation'

const navigationConfig: NavigationTree[] = [
    {
        key: 'home',
        path: '/home',
        title: 'Inicio',
        translateKey: 'nav.home',
        icon: 'home',
        type: NAV_ITEM_TYPE_ITEM,
        authority: [],
        subMenu: [],
    },
    {
        key: 'register',
        path: '/register',
        title: 'Cadastro',
        translateKey: 'nav.register',
        icon: 'register',
        type: NAV_ITEM_TYPE_COLLAPSE,
        authority: [],
        subMenu: [
            {
                key: 'register.customers',
                path: '/register/customers',
                title: 'Clientes',
                translateKey: 'nav.register.customers',
                icon: '',
                type: NAV_ITEM_TYPE_ITEM,
                authority: [],
                subMenu: [],
            },
            {
                key:'register.customers.create',
                path: '/register/customers/create',
                title: 'Novo cliente',
                translateKey: 'nav.register.customers.create',
                icon: '',
                type: NAV_ITEM_TYPE_ITEM,
                authority: [],
                subMenu: [],
            },
        ],
    },
]

export default navigationConfig
