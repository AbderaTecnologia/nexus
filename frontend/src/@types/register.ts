import { AddressFields, OverviewFields } from "@/views/modules/register/customers/Form/types"

export type CustomersList = {
    result: Customer[]
}

export type Customer = {
    id: string
    type: string
    name: string
    email: string
    phone: string
    cpfCnpj: string
}

export type CustomerRequest = {
    overview: OverviewFields,
    address: AddressFields
}