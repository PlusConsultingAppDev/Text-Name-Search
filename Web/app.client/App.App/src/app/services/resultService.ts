import * as proxy from "core/services/apiProxy";
import { ResultModel } from "models";

export async function getAll(): Promise<ResultModel[]> {
  return await proxy.get<ResultModel[]>(`/result/getall/`);
}
