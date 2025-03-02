import { Customer } from "@/@types/register";
import { Card } from "@/components/ui";
import Table from "@/components/ui/Table";
import { apiGetCustomersList } from "@/services/modules/cadastro/CustomersService";
import { useEffect, useState } from "react";

const { Tr, Th, Td, THead, TBody } = Table;

const ListCustomers = () => {
    const [customersList, setCustomersList] = useState<Customer[]>([]);
    useEffect(() => {
        const getCustomersList = async () => {
            const response = await apiGetCustomersList();
            setCustomersList(response);
        };
        getCustomersList();
    }, []);
    return (
        <Card>
            <Table>
                <THead>
                    <Tr>
                        <Th>Nome</Th>
                        <Th>CPF/CNPJ</Th>
                        <Th>Tipo</Th>
                        <Th>Email</Th>
                    </Tr>
                </THead>
                <TBody>
                    {customersList.map((customer) => (
                        <Tr key={customer.id}>
                            <Td>{customer.name}</Td>
                            <Td>{customer.cpfCnpj}</Td>
                            <Td>{customer.type}</Td>
                            <Td>{customer.email}</Td>
                        </Tr>
                    ))}
                </TBody>
            </Table>
        </Card>
    )
}

export default ListCustomers;