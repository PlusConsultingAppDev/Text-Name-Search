import * as React from "react";
import { Route, Switch } from "react-router";
import { App as TextSearchApp } from "views/App";
import { LoginView } from "views/Login";
import { SearchView } from "views/search/searchView";
import { HistoryView } from "views/history/historyView";
import { hot } from "react-hot-loader";

export const App = hot(module)(() => (
  <>
    <Switch>
      <Route path="/search" component={SearchView} />
      <Route path="/history" component={HistoryView} />
      <Route path="/login" component={LoginView} />
      <Route path="" component={TextSearchApp} />
    </Switch>
  </>
));
