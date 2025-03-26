import Card from '@/components/ui/Card'
import Input from '@/components/ui/Input'
import { FormItem } from '@/components/ui/Form'
import { Controller } from 'react-hook-form'
import type { FormSectionBaseProps } from './types'
import FormCustomFormatInput from '@/components/shared/CustomFormatInput'

type AddressSectionProps = FormSectionBaseProps

const AddressSection = ({ control, errors }: AddressSectionProps) => {
    return (
        <Card>
            <h4 className="mb-6">Endereço</h4>
            <div className="grid md:grid-cols-2 gap-4">
                <FormItem
                    label="Rua"
                    invalid={Boolean(errors.address?.street)}
                    errorMessage={errors.address?.street?.message}
                >
                    <Controller
                        name="address.street"
                        control={control}
                        render={({ field }) => (
                            <Input
                                type="text"
                                autoComplete="off"
                                placeholder="Ex.: Rua das Flores"
                                {...field}
                            />
                        )}
                    />
                </FormItem>
                <FormItem
                    label="Número"
                    invalid={Boolean(errors.address?.number)}
                    errorMessage={errors.address?.number?.message}
                >
                    <Controller
                        name="address.number"
                        control={control}
                        render={({ field }) => (
                            <Input
                                type="text"
                                autoComplete="off"
                                placeholder="Ex.: 123"
                                {...field}
                            />
                        )}
                    />
                </FormItem>
                <FormItem
                    label="Bairro"
                    invalid={Boolean(errors.address?.neighborhood)}
                    errorMessage={errors.address?.neighborhood?.message}
                >
                    <Controller
                        name="address.neighborhood"
                        control={control}
                        render={({ field }) => (
                            <Input
                                type="text"
                                autoComplete="off"
                                placeholder="Ex.: Jardim das Flores"
                                {...field}
                            />
                        )}
                    />
                </FormItem>
                <FormItem
                    label="Complemento"
                    invalid={Boolean(errors.address?.complement)}
                    errorMessage={errors.address?.complement?.message}
                >
                    <Controller
                        name="address.complement"
                        control={control}
                        render={({ field }) => (
                            <Input
                                type="text"
                                autoComplete="off"
                                placeholder="Ex.: Apartamento 45"
                                {...field}
                            />
                        )}
                    />
                </FormItem>
                <FormItem
                    label="CEP"
                    invalid={Boolean(errors.address?.zipCode)}
                    errorMessage={errors.address?.zipCode?.message}
                >
                    <Controller
                        name="address.zipCode"
                        control={control}
                        render={({ field }) => (
                            <FormCustomFormatInput
                                type="text"
                                autoComplete="off"
                                placeholder="Ex.: 12345-678"
                                {...field}
                                format={(value: string) => {
                                    return value
                                        .replace(/\D/g, '')
                                        .replace(/(\d{5})(\d)/, '$1-$2')
                                }}
                                removeFormatting={(value: string) => value.replace(/\D/g, '')} // Remove a máscara
                                onValueChange={(values) => field.onChange(values.value)} // Atualiza o valor bruto no estado
                            />
                        )}
                    />
                </FormItem>
                <FormItem
                    label="Cidade"
                    invalid={Boolean(errors.address?.city)}
                    errorMessage={errors.address?.city?.message}
                >
                    <Controller
                        name="address.city"
                        control={control}
                        render={({ field }) => (
                            <Input
                                type="text"
                                autoComplete="off"
                                placeholder="Ex.: São Paulo"
                                {...field}
                            />
                        )}
                    />
                </FormItem>
                <FormItem
                    label="Estado"
                    invalid={Boolean(errors.address?.state)}
                    errorMessage={errors.address?.state?.message}
                >
                    <Controller
                        name="address.state"
                        control={control}
                        render={({ field }) => (
                            <Input
                                type="text"
                                autoComplete="off"
                                placeholder="Ex.: SP"
                                {...field}
                            />
                        )}
                    />
                </FormItem>
            </div>
        </Card>
    )
}

export default AddressSection