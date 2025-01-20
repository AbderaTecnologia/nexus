import ApiService from "../ApiService";

export async function apiGetFuncionarioList() {
    return ApiService.fetchDataWithAxios<
        {
            result: {
                id: string
                nomeCompleto: string
                dataNascimento: string
                cidade: string
                uf: string
            }[]
        }
    >({
        url: '/folha',
        method: 'get',
    })
}