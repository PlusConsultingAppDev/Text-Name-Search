import * as proxy from "core/services/apiProxy";
import { ArticleModel } from "models";

export async function getAll(): Promise<ArticleModel[]> {
  return await proxy.get<ArticleModel[]>(`/article/getall/`);
}
