import React, { Component } from 'react';
import { Route,Switch } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { WordSearch } from './components/WordSearch';
import { bootstrapTest1 } from './components/bootstrap1';
import { NotFound } from './components/NotFound';
import TestForm  from './components/testForm';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
        <Layout>
        <Switch>    
            <Route exact path='/' component={WordSearch} />
            <Route path='/Home' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetchdata' component={FetchData} />
            <Route path='/wordsearch/:name' component={WordSearch} />
            <Route path='/wordsearch' component={WordSearch} />
            <Route path='/bootstrapTest1' component={bootstrapTest1} />
            <Route path='/testform' component={TestForm} />
            <Route path='/*' component={NotFound} />
        </Switch>

     </Layout>
    );
  }
}
