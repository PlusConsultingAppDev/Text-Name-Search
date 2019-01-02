import { createAction } from "redux-actions";
import { ArticleModel } from "models";

export namespace ArticleActions {
  export enum Type {
    ADD_OVERWRITE_ARTICLE = "ADD_OVERWRITE_ARTICLE",
  }

  export const AddOverwriteArticle = createAction<ArticleModel[]>(Type.ADD_OVERWRITE_ARTICLE);

}

export type ArticleActions = Omit<typeof ArticleActions, "Type">;
