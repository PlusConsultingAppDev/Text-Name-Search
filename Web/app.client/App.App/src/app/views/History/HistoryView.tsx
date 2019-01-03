import * as React from "react";
import { bindActionCreators, Dispatch } from "redux";
import { connect } from "react-redux";
import { SearchActions } from "app/actions";
import * as SearchService from "app/services/searchService";
import { Shell } from "app/components/Shell/shell";
import { RootState } from "app/reducers";
import { omit } from "core/utils";
import * as _ from "lodash";
import * as moment from "moment";

import { SearchResultViewModel } from "app/models";
export namespace HistoryView {
  export interface FluxProps {
    SearchResultViewState: RootState.SearchResultViewState;
  }

  export interface DispatchProps {
    searchActions: SearchActions;
  }
}

@connect(
  (state: RootState, ownProps): Pick<HistoryView.FluxProps,
    "SearchResultViewState"> => {
    return {
      SearchResultViewState: state.searchViewData,
    };
  },
  (dispatch: Dispatch): Pick<HistoryView.DispatchProps,
    "searchActions"> => ({
      searchActions: bindActionCreators(omit(SearchActions, "Type"), dispatch),
    }),
)

export class HistoryView extends React.Component<HistoryView.FluxProps & HistoryView.DispatchProps, {}> {
  // tslint:disable-next-line:no-any
  constructor(props: HistoryView.FluxProps & HistoryView.DispatchProps, context?: any) {
    super(props, context);
  }

  public async componentDidMount(): Promise<void> {
    const searchResults = await SearchService.getSearchResults();
    this.props.searchActions.AddOverwriteSearchResults(searchResults);
  }

  public render(): JSX.Element {
    const searchItems = _.uniqBy(this.props.SearchResultViewState, "searchIdentifier");
    const searchResultContainerStyle = {
      width: "600px",
      marginTop: "12px",
    } as React.CSSProperties;
    return (
      <>
        <Shell hideFooter={true}>
          <div className="pure-form">
            <h1>
              Saved Search History Page
            </h1>
            <div style={searchResultContainerStyle}>
              {searchItems.map((result, index) => (this.renderSearchData(result)))}
            </div>
          </div>
        </Shell>
      </>
    );
  }

  private renderSearchData(searchItem: SearchResultViewModel): JSX.Element {
    const labelStyle = {
      fontWeight: "bold",
    } as React.CSSProperties;
    const resultStyle = {
      backgroundColor: "#696969",
      borderRadius: 12,
      marginTop: "18px",
      marginLeft: "18px",
    } as React.CSSProperties;
    const itemStyle = {
      marginLeft: "18px",
    } as React.CSSProperties;
    const occurrenceStyle = {
      paddingLeft: "38px",
    } as React.CSSProperties;
    return (
      <div style={resultStyle}>
        <div style={itemStyle}>
          <span style={labelStyle}>Search Id:&nbsp;</span>
          {searchItem.searchIdentifier.toString()}
        </div>
        <div style={itemStyle}>
          <span style={labelStyle}>Date:&nbsp;</span>
          {moment(searchItem.searchDate).format("MM/DD/YYYY")}
        </div>
        <div style={itemStyle}>
          <span style={labelStyle}>Total Occurrences:&nbsp;</span>
          {_(this.props.SearchResultViewState)
            .filter(item => item.searchIdentifier === searchItem.searchIdentifier)
            .reduce((s, o) => s + o.occurrences, 0)}
        </div>
        <div>
          {this.props.SearchResultViewState
            .filter(item => item.searchIdentifier === searchItem.searchIdentifier)
            .map(item => (
              <div style={{ width: "600px" }}>
                <div>
                  <i style={occurrenceStyle}>{item.searchText} ({item.occurrences})</i>
                </div>
              </div>
            ))}
        </div>
      </div>
    );
  }
}
