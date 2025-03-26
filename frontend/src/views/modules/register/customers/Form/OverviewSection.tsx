import { useMemo } from 'react'
import Card from '@/components/ui/Card'
import Input from '@/components/ui/Input'
import Select, { Option as DefaultOption } from '@/components/ui/Select'
import Avatar from '@/components/ui/Avatar'
import { FormItem } from '@/components/ui/Form'
import NumericInput from '@/components/shared/NumericInput'
import { countryList } from '@/constants/countries.constant'
import { Controller } from 'react-hook-form'
import { components } from 'react-select'
import type { FormSectionBaseProps } from './types'
import type { ControlProps, OptionProps } from 'react-select'
import FormCustomFormatInput from '@/components/shared/CustomFormatInput'

type OverviewSectionProps = FormSectionBaseProps

type CountryOption = {
    label: string
    dialCode: string
    value: string
}

const { Control } = components

const CustomSelectOption = (props: OptionProps<CountryOption>) => {
    return (
        <DefaultOption<CountryOption>
            {...props}
            customLabel={(data) => (
                <span className="flex items-center gap-2">
                    <Avatar
                        shape="circle"
                        size={20}
                        src={`/img/countries/${data.value}.png`}
                    />
                    <span>{data.dialCode}</span>
                </span>
            )}
        />
    )
}

const CustomControl = ({ children, ...props }: ControlProps<CountryOption>) => {
    const selected = props.getValue()[0]
    return (
        <Control {...props}>
            {selected && (
                <Avatar
                    className="ltr:ml-4 rtl:mr-4"
                    shape="circle"
                    size={20}
                    src={`/img/countries/${selected.value}.png`}
                />
            )}
            {children}
        </Control>
    )
}

const OverviewSection = ({ control, errors }: OverviewSectionProps) => {
    const dialCodeList = useMemo(() => {
        const newCountryList: Array<CountryOption> = JSON.parse(
            JSON.stringify(countryList),
        )

        return newCountryList.map((country) => {
            country.label = country.dialCode
            return country
        })
    }, [])

    return (
        <Card>
            <h4 className="mb-6">Dados básicos</h4>
            <div className="grid md:grid-cols-2 gap-4">
                <FormItem
                    label="Nome completo ou Razão Social"
                    invalid={Boolean(errors.overview?.nome)}
                    errorMessage={errors.overview?.nome?.message}
                >
                    <Controller
                        name="overview.nome"
                        control={control}
                        render={({ field }) => (
                            <Input
                                type="text"
                                autoComplete="off"
                                placeholder="Ex.: Abdera LTDA"
                                {...field}
                            />
                        )}
                    />
                </FormItem>
                <FormItem
                    label="CPF ou CNPJ"
                    invalid={Boolean(errors.overview?.cpfCnpj)}
                    errorMessage={errors.overview?.cpfCnpj?.message}
                >
                    <Controller
                        name="overview.cpfCnpj"
                        control={control}
                        render={({ field }) => (
                            <FormCustomFormatInput
                                {...field}
                                placeholder="Ex.: 000.000.000-00 ou 00.000.000/0000-00"
                                format={(value: string) => {
                                    // Aplica a máscara de CPF ou CNPJ dinamicamente
                                    const onlyNumbers = value.replace(/\D/g, '')
                                    if (onlyNumbers.length <= 11) {
                                        // Máscara de CPF
                                        return onlyNumbers
                                            .replace(/(\d{3})(\d)/, '$1.$2')
                                            .replace(/(\d{3})(\d)/, '$1.$2')
                                            .replace(/(\d{3})(\d{1,2})$/, '$1-$2')
                                    } else {
                                        // Máscara de CNPJ
                                        return onlyNumbers
                                            .replace(/(\d{2})(\d)/, '$1.$2')
                                            .replace(/(\d{3})(\d)/, '$1.$2')
                                            .replace(/(\d{3})(\d)/, '$1/$2')
                                            .replace(/(\d{4})(\d{1,2})$/, '$1-$2')
                                    }
                                }}
                                removeFormatting={(value: string) => value.replace(/\D/g, '')} // Remove a máscara
                                onValueChange={(values) => field.onChange(values.value)} // Atualiza o valor bruto no estado
                            />
                        )}
                    />
                </FormItem>
            </div>
            <FormItem
                label="Email"
                invalid={Boolean(errors.overview?.email)}
                errorMessage={errors.overview?.email?.message}
            >
                <Controller
                    name="overview.email"
                    control={control}
                    render={({ field }) => (
                        <Input
                            type="email"
                            autoComplete="off"
                            placeholder="Ex.: nexus@abdera.com.br"
                            {...field}
                        />
                    )}
                />
            </FormItem>
        </Card>
    )
}

export default OverviewSection
