import { Card } from '@/components/ui'
import Table from '@/components/ui/Table'
import { apiGetFuncionarioList } from '@/services/folha/FuncionarioService'
import { useEffect, useState } from 'react'

type FuncionarioList = {
    id: string
    nomeCompleto: string
    dataNascimento: string
    cidade: string
    uf: string
}

const { Tr, Th, Td, THead, TBody } = Table

const FuncionarioList = () => {
    const [funcionarioList, setFuncionarioList] = useState<FuncionarioList[]>([])

    useEffect(() => {
        const getFuncionarioList = async () => {
            const resp = await apiGetFuncionarioList()
            setFuncionarioList(resp.result)
        }

        getFuncionarioList()
    }, [])

    return (
        <Card>
            <Table>
                <THead>
                    <Tr>
                        <Th>Nome Completo</Th>
                        <Th>Data de Nascimento</Th>
                        <Th>Cidade</Th>
                        <Th>UF</Th>
                    </Tr>
                </THead>
                <TBody>
                    {funcionarioList.map((funcionario) => (
                        <Tr key={funcionario.id}>
                            <Td>{funcionario.nomeCompleto}</Td>
                            <Td>{funcionario.dataNascimento}</Td>
                            <Td>{funcionario.cidade}</Td>
                            <Td>{funcionario.uf}</Td>
                        </Tr>
                    ))}
                </TBody>
            </Table>
        </Card>
    )
}

export default FuncionarioList