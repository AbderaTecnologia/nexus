import { useState } from 'react'
import Input from '@/components/ui/Input'
import Spinner from '@/components/ui/Spinner'
import { HiCheck, HiX } from 'react-icons/hi'
import type { CommonProps } from '@/@types/common'
import type { InputProps } from '@/components/ui/Input'
import type { ChangeEvent } from 'react'

interface CepInputProps extends CommonProps, Omit<InputProps, 'onChange' | 'onError'> {
    onChange?: (cep: string, address?: Address) => void
    onError?: (error: string) => void
}

interface Address {
    cep: string
    logradouro: string
    bairro: string
    cidade: string
    uf: string
}

const CepInput = ({ onChange, onError, ...rest }: CepInputProps) => {
    const [loading, setLoading] = useState(false)
    const [isValid, setIsValid] = useState<boolean | null>(null)

    const formatCep = (value: string) => {
        return value.replace(/\D/g, '').replace(/(\d{5})(\d)/, '$1-$2')
    }

    const consultCep = async (cep: string) => {
        try {
            setLoading(true)
            const response = await fetch(`https://viacep.com.br/ws/${cep}/json/`)
            const data = await response.json()

            if (!data.cep || data.erro) {
                setIsValid(false)
                onError?.('CEP não encontrado')
                return
            }

            const address: Address = {
                cep: data.cep,
                logradouro: data.logradouro || '',
                bairro: data.bairro || '',
                cidade: data.localidade || '',
                uf: data.uf || '',
            }

            setIsValid(true)
            onChange?.(cep, address)
        } catch (error) {
            setIsValid(false)
            onError?.('Erro ao consultar CEP')
        } finally {
            setLoading(false)
        }
    }

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        const value = formatCep(e.target.value)
        onChange?.(value)

        if (value.length === 9) {
            const cleanCep = value.replace('-', '')
            consultCep(cleanCep)
        } else {
            setIsValid(null)
        }
    }

    const getSuffix = () => {
        if (loading) return <Spinner size={20} />
        if (isValid === true) return <HiCheck className="text-emerald-500 text-xl" />
        if (isValid === false) return <HiX className="text-red-500 text-xl" />
        return null
    }

    return (
        <Input
            {...rest}
            value={rest.value}
            onChange={handleChange}
            maxLength={9}
            suffix={getSuffix()}
            placeholder="00000-000"
        />
    )
}

export type { Address }
export default CepInput