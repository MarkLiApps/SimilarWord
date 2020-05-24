import React, { Component } from 'react';
import { Route,Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { WordSearch } from './components/WordSearch';
import { BootstrapTest1 } from './components/bootstrap1';
import { NotFound } from './components/NotFound';
import WordEdit from './components/WordEdit';
import DashBoard from './components/DashBoard';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
        <Layout>
        <Switch>    
            <Route exact path='/' component={DashBoard} />
            <Route path='/Home' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetchdata' component={FetchData} />
            <Route path='/dashboard' component={DashBoard} />
            <Route path='/wordsearch/:name' component={WordSearch} />
            <Route path='/wordsearch' component={WordSearch} />
            <Route path='/wordedit/:name' component={WordEdit} />
            <Route path='/bootstraptest1' component={BootstrapTest1} />
            <Route path='/*' component={NotFound} />
        </Switch>

     </Layout>
    );
  }
}
