export type GeneralFields = {
    name: string;
    description?: string;
    barCode: string;
    unitOfMeasure: string;
}

export type PriceFields = {
    price: number | string;
    costPrice: number | string;
}

export type ProductFormSchema = GeneralFields &
    PriceFields