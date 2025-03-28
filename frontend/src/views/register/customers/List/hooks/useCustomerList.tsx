import { apiGetCustomersList2 } from '@/services/modules/cadastro/CustomersService'
import useSWR from 'swr'
import type { GetCustomersListResponse } from '../types'
import type { TableQueries } from '@/@types/common'
import { useCustomerListStore } from '../store/customerListStore'

export default function useCustomerList() {
    const {
        tableData,
        filterData,
        setTableData,
        selectedCustomer,
        setSelectedCustomer,
        setSelectAllCustomer,
        setFilterData,
    } = useCustomerListStore((state) => state)

    const { data, error, isLoading, mutate } = useSWR(
        ['/api/cadastro/cliente/list', { ...tableData, ...filterData }],
        // eslint-disable-next-line @typescript-eslint/no-unused-vars
        ([_, params]) => apiGetCustomersList2<GetCustomersListResponse, TableQueries>(params), {
            revalidateOnFocus: false,
        },
    )

    const customerList = data?.result || []

    const customerListTotal = data?.result.length || 0

    return {
        customerList,
        customerListTotal,
        error,
        isLoading,
        tableData,
        filterData,
        mutate,
        setTableData,
        selectedCustomer,
        setSelectedCustomer,
        setSelectAllCustomer,
        setFilterData,
    }
}