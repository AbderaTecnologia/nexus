import { CommonProps } from "@/@types/common";
import { ProductFormSchema } from "./types";
import { z, ZodType } from "zod";

type ProductFormProps = {
    onFormSubmit: (values: ProductFormSchema) => void
    defaultValues?: ProductFormSchema
    newProduct?: boolean
} & CommonProps

const validationSchema: ZodType<ProductFormSchema> = z.object({
    name: z.string().min(1, "Name is required"),
    description: z.string().optional(),
    barCode: z.string().min(1, "Bar code is required"),
    unitOfMeasure: z.string().min(1, "Unit of measure is required"),
    price: z.union([z.string(), z.number()], {
        errorMap: () => ({ message: 'Price required!' }),
    }),
    costPrice: z.union([z.string(), z.number()], {
        errorMap: () => ({ message: 'Price required!' }),
    }),
});