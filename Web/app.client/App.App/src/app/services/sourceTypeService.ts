import * as proxy from "core/services/apiProxy";
import { SourceTypeModel } from "models";

export async function getAll(): Promise<SourceTypeModel[]> {
  return await proxy.get<SourceTypeModel[]>(`/sourcetype/getall/`);
}
