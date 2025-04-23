import { useState } from 'react'
import Container from '@/components/shared/Container'
import Button from '@/components/ui/Button'
import Notification from '@/components/ui/Notification'
import toast from '@/components/ui/toast'
import CustomerForm from '../Form'
import ConfirmDialog from '@/components/shared/ConfirmDialog'
import sleep from '@/utils/sleep'
import { TbTrash } from 'react-icons/tb'
import { useNavigate } from 'react-router-dom'
import type { CustomerFormSchema } from '../Form'
import { apiPostCustomer } from '@/services/modules/cadastro/CustomersService'

const CustomerEdit = () => {
    const navigate = useNavigate()

    const [discardConfirmationOpen, setDiscardConfirmationOpen] =
        useState(false)
    const [isSubmiting, setIsSubmiting] = useState(false)

    const handleFormSubmit = async (values: CustomerFormSchema) => {
        console.log('Submitted values', values)
        setIsSubmiting(true)
        await apiPostCustomer(values)
        setIsSubmiting(false)
        toast.push(
            <Notification type="success">Cliente cadastrado!</Notification>,
            { placement: 'top-center' },
        )
        navigate('/register/customers/list')
    }

    const handleConfirmDiscard = () => {
        setDiscardConfirmationOpen(true)
        toast.push(
            <Notification type="success">Cadastro de cliente descartado!</Notification>,
            { placement: 'top-center' },
        )
        navigate('/register/customers/list')
    }

    const handleDiscard = () => {
        setDiscardConfirmationOpen(true)
    }

    const handleCancel = () => {
        setDiscardConfirmationOpen(false)
    }

    return (
        <>
            <CustomerForm
                newCustomer
                defaultValues={{
                    overview: {
                        nome: '',
                        cpfCnpj: '',
                        email: '',
                    },
                    address: {
                        zipCode: '',
                        street: '',
                        number: '',
                        neighborhood: '',
                        city: '',
                        state: '',
                        country: '',
                        complement: '',
                    },
                    profileImage: {
                        img: '',
                    },
                }}
                onFormSubmit={handleFormSubmit}
            >
                <Container>
                    <div className="flex items-center justify-between px-8">
                        <span></span>
                        <div className="flex items-center">
                            <Button
                                className="ltr:mr-3 rtl:ml-3"
                                type="button"
                                customColorClass={() =>
                                    'border-error ring-1 ring-error text-error hover:border-error hover:ring-error hover:text-error bg-transparent'
                                }
                                icon={<TbTrash />}
                                onClick={handleDiscard}
                            >
                                Descartar
                            </Button>
                            <Button
                                variant="solid"
                                type="submit"
                                loading={isSubmiting}
                            >
                                Criar
                            </Button>
                        </div>
                    </div>
                </Container>
            </CustomerForm>
            <ConfirmDialog
                isOpen={discardConfirmationOpen}
                type="danger"
                title="Descartar"
                onClose={handleCancel}
                onRequestClose={handleCancel}
                onCancel={handleCancel}
                onConfirm={handleConfirmDiscard}
            >
                <p>
                    Tem certeza de que deseja descartar o cadastro do novo cliente? Esta ação não pode
                    ser desfeita.
                </p>
            </ConfirmDialog>
        </>
    )
}

export default CustomerEdit
