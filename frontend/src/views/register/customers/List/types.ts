export type GetCustomersListResponse = {
    result: Customer[] //ToDo: Substituir result por list
}

export type Customer = {
    id: string
    type: string
    name: string
    email: string
    phone: string
    cpfCnpj: string
}

export type Filter = {
    purchasedProducts: string
    purchaseChannel: Array<string>
}