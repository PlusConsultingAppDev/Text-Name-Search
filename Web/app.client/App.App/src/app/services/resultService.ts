import * as proxy from "core/services/apiProxy";
import { ResultModel } from "models";

export async function getAll(): Promise<ResultModel[]> {
  return await proxy.get<ResultModel[]>(`/result/getall/`);
}

export async function add(results: ResultModel[]): Promise<void> {
  await proxy.post(`/result/add/`, results);
}
