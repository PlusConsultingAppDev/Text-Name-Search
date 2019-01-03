import * as proxy from "core/services/apiProxy";
import { SearchModel, SearchResultViewModel } from "models";

export async function search(firstName: string, lastName: string, middleName: string): Promise<SearchModel> {
  return await proxy.get<SearchModel>(`search/first/${firstName}/last/${lastName}/middle/${middleName}`);
}

export async function getSearchResults(): Promise<SearchResultViewModel[]> {
  return await proxy.get<SearchResultViewModel[]>(`search/view`);
}
