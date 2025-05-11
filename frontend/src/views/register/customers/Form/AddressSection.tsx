import Card from '@/components/ui/Card'
import Input from '@/components/ui/Input'
import { FormItem } from '@/components/ui/Form'
import { Controller } from 'react-hook-form'
import CepInput, { Address } from '@/components/shared/CepInput'
import type { FormSectionBaseProps } from './types'

type AddressSectionProps = FormSectionBaseProps

const AddressSection = ({ control, setValue, errors }: AddressSectionProps) => {
    const handleAddressUpdate = (address: Address) => {
        const updates = {
            'address.street': address.logradouro,
            'address.neighborhood': address.bairro,
            'address.city': address.cidade,
            'address.state': address.uf
        }

        Object.entries(updates).forEach(([field, value]) => {
            setValue(field as 'address.street', value, {
                shouldValidate: true,
                shouldDirty: true,
                shouldTouch: true
            })
        })
    }

    return (
        <Card>
            <h4 className="mb-6">Endereço</h4>
            <div className="grid md:grid-cols-2 gap-4">
                <FormItem
                    label="CEP"
                    invalid={Boolean(errors.address?.zipCode)}
                    errorMessage={errors.address?.zipCode?.message}
                >
                    <Controller
                        name="address.zipCode"
                        control={control}
                        render={({ field }) => (
                            <CepInput
                                {...field}
                                onChange={(cep, address) => {
                                    field.onChange(cep)
                                    if (address) {
                                        handleAddressUpdate(address)
                                    }
                                }}
                            />
                        )}
                    />
                </FormItem>

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