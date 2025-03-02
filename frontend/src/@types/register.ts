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
    nome: string,
    cpfCnpj: string,
    email: string,
}