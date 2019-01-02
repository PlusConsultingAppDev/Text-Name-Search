import * as React from "react";
import { bindActionCreators, Dispatch } from "redux";
import { connect } from "react-redux";
import { ArticleActions, SourceTypeActions, ResultActions } from "app/actions";
import * as ArticleService from "app/services/articleService";
import * as ResultService from "app/services/resultService";
import * as SourceTypeService from "app/services/sourceTypeService";
import { Shell } from "app/components/Shell/shell";
// import { ArticleModel, ResultModel, SourceTypeModel } from "models";
import { RootState } from "app/reducers";
import { omit } from "core/utils";

export namespace HistoryView {
  export interface FluxProps {
    ArticleState: RootState.ArticleState;
    ResultState: RootState.ResultState;
    SourceTypeState: RootState.SourceTypeState;
    AuthenticationState: RootState.AuthenticationState;
    articleActions: ArticleActions;
    resultActions: ResultActions;
    sourceTypeActions: SourceTypeActions;

  }
}

@connect(

  (state: RootState, ownProps): Pick<HistoryView.FluxProps, "ArticleState" | "ResultState" | "SourceTypeState" | "AuthenticationState"> => {
    return {
      AuthenticationState: state.authenticationData,
      ArticleState: state.articleData, SourceTypeState:
        state.sourceTypeData,
      ResultState: state.resultData,
    };
  },
  (dispatch: Dispatch): Pick<HistoryView.FluxProps, "articleActions" | "resultActions" | "sourceTypeActions"> => ({
    articleActions: bindActionCreators(omit(ArticleActions, "Type"), dispatch),
    resultActions: bindActionCreators(omit(ResultActions, "Type"), dispatch),
    sourceTypeActions: bindActionCreators(omit(SourceTypeActions, "Type"), dispatch),
  }),
)

export class HistoryView extends React.Component<HistoryView.FluxProps, {}> {
  // tslint:disable-next-line:no-any
  constructor(props: HistoryView.FluxProps, context?: any) {
    super(props, context);
    this.state = {
    };
  }

  public async componentDidMount(): Promise<void> {
    const articles = await ArticleService.getAll();
    this.props.articleActions.AddOverwriteArticle(articles);

    const results = await ResultService.getAll();
    this.props.resultActions.AddOverwriteResults(results);

    const sourceTypes = await SourceTypeService.getAll();
    this.props.sourceTypeActions.AddOverwriteSourceType(sourceTypes);
  }

  public render(): JSX.Element {

    if (!this.props.ArticleState || this.props.ArticleState.length === 0 ||
      !this.props.ResultState || this.props.ResultState.length === 0 ||
      !this.props.SourceTypeState || this.props.SourceTypeState.length === 0) {
      return (<div>Loading Data...</div>);
    }

    const dateContainerStyle = {
      width: "220px",
      marginTop: "20px",
    } as React.CSSProperties;

    const tabContainerStyle = {
      width: "800px",
      marginTop: "20px",
    } as React.CSSProperties;

    return (
      <>
        <Shell hideFooter={true}>
          <div>
            <div>
              <div>
                <div style={dateContainerStyle}>
                  ITEM HERE
                </div>
              </div>
              <div style={tabContainerStyle}>
                BUTTONS
              </div>
              BODY HERE
            </div>
          </div>
        </Shell>
      </>
    );
  }
}
