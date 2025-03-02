import { lazy } from 'react'
import authRoute from './authRoute'
import othersRoute from './othersRoute'
import type { Routes } from '@/@types/routes'
import registerRoute from './registerRoute'

export const publicRoutes: Routes = [...authRoute]

export const protectedRoutes: Routes = [
    {
        key: 'home',
        path: '/home',
        component: lazy(() => import('@/views/dashboards/EcommerceDashboard')),
        authority: [],
        meta: {
            pageContainerType: 'contained',
        },
    },
    ...othersRoute,
    ...registerRoute,
]
