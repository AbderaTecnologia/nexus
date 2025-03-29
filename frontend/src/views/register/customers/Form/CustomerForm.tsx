import { useEffect, useState } from 'react'
import { Form } from '@/components/ui/Form'
import Container from '@/components/shared/Container'
import BottomStickyBar from '@/components/template/BottomStickyBar'
import Steps from '@/components/ui/Steps'
import { Button } from '@/components/ui'
import OverviewSection from './OverviewSection'
import AddressSection from './AddressSection'
import ProfileImageSection from './ProfileImageSection'
// import AccountSection from './AccountSection'
import isEmpty from 'lodash/isEmpty'
import { zodResolver } from '@hookform/resolvers/zod'
import { useForm } from 'react-hook-form'
import { z } from 'zod'
import type { ZodType } from 'zod'
import type { CommonProps } from '@/@types/common'
import type { CustomerFormSchema } from './types'

type CustomerFormProps = {
    onFormSubmit: (values: CustomerFormSchema) => void
    defaultValues?: CustomerFormSchema
    newCustomer?: boolean
} & CommonProps

const validationSchema: ZodType<CustomerFormSchema> = z.object({
    overview: z.object({
        nome: z.string().min(1, { message: 'Nome ou Razão Social obrigatório' }),
        email: z
            .string()
            .min(1, { message: 'Email obrigatório' })
            .email({ message: 'Email inválido' }),
        cpfCnpj: z.string()
            .min(11, { message: 'Cpf ou Cnpj obrigatório' })
            .max(14, { message: 'Documento inválido' }),
    }),
    address: z.object({
        zipCode: z.string().min(1, { message: 'CEP obrigatório' }),
        street: z.string().min(1, { message: 'Rua obrigatória' }),
        number: z.string().min(1, { message: 'Número obrigatório' }),
        neighborhood: z.string().min(1, { message: 'Bairro obrigatório' }),
        city: z.string().min(1, { message: 'Cidade obrigatória' }),
        state: z.string().min(1, { message: 'Estado obrigatório' }),
        country: z.string().min(1, { message: 'País obrigatório' }),
        complement: z.string(),
    }),
    img: z.string().optional()
})

const CustomerForm = (props: CustomerFormProps) => {
    const {
        onFormSubmit,
        defaultValues = {},
        newCustomer = false,
        children,
    } = props

    const [currentStep, setCurrentStep] = useState(0)

    const {
        handleSubmit,
        reset,
        formState: { errors },
        control,
        setValue,
        trigger
    } = useForm<CustomerFormSchema>({
        defaultValues: {
            ...defaultValues,
        },
        resolver: zodResolver(validationSchema),
    })

    useEffect(() => {
        if (!isEmpty(defaultValues)) {
            reset(defaultValues)
        }
    }, [JSON.stringify(defaultValues)])

    const handleNextStep = async () => {
            setCurrentStep(1)
    }

    const onSubmit = (values: CustomerFormSchema) => {
        if (currentStep === 1) {
            onFormSubmit?.(values)
        }
    }

    return (
        <Form
            className="flex w-full h-full"
            containerClassName="flex flex-col w-full justify-between"
            onSubmit={handleSubmit(onSubmit)}
        >
            <Container>
                <div className="mb-8">
                    <Steps current={currentStep}>
                        <Steps.Item title="Basic Info & Address" />
                        <Steps.Item title="Profile Image" />
                    </Steps>
                </div>
                
                {currentStep === 0 ? (
                    <div className="flex flex-col md:flex-row gap-4">
                        <div className="gap-4 flex flex-col flex-auto">
                            <OverviewSection control={control} setValue={setValue} errors={errors} />
                            <AddressSection control={control} setValue={setValue} errors={errors} />
                        </div>
                    </div>
                ) : (
                    <div className="md:w-[370px] mx-auto">
                        <ProfileImageSection
                            control={control}
                            errors={errors}
                            setValue={setValue}
                        />
                    </div>
                )}
            </Container>
            <BottomStickyBar>
                {currentStep === 0 ? (
                    <Button type='button' variant="solid" onClick={handleNextStep}>
                        Next Step
                    </Button>
                ) : (
                    children
                )}
            </BottomStickyBar>
        </Form>
    )
}

export default CustomerForm
