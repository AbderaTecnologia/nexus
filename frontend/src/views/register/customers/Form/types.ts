import type { Control, FieldErrors, UseFormSetValue } from 'react-hook-form'

export type OverviewFields = {
    nome: string
    cpfCnpj: string
    email: string
}

export type AddressFields = {
    zipCode: string
    street: string
    number: string
    neighborhood: string
    city: string
    state: string
    country: string
    complement: string
}

export type ProfileImageFields = {
    img: string
}

export type TagsFields = {
    tags: Array<{ value: string; label: string }>
}

export type AccountField = {
    banAccount?: boolean
    accountVerified?: boolean
}

export type CustomerFormSchema = {
    overview: OverviewFields
    address: AddressFields
    //profileImage: ProfileImageFields
    //tags: TagsFields
    //account: AccountField
}

export type FormSectionBaseProps = {
    control: Control<CustomerFormSchema>
    setValue: UseFormSetValue<CustomerFormSchema>
    errors: FieldErrors<CustomerFormSchema>
}
