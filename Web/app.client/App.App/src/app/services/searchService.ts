import * as proxy from "core/services/apiProxy";
import { SearchModel } from "models";

export async function search(): Promise<SearchModel[]> {
  return await proxy.get<SearchModel[]>(`/search/`);
}
