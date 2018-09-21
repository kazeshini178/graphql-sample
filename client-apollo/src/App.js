import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import { gql, HttpLink, ApolloLink, InMemoryCache } from 'apollo-boost';
import { ApolloClient } from 'apollo-client';
import { WebSocketLink } from 'apollo-link-ws'

import { Query, ApolloProvider, Subscription } from 'react-apollo';


const hasSubscriptionOperation = ({ query: { definitions } }) =>
  definitions.some(
    ({ kind, operation }) =>
      kind === 'OperationDefinition' && operation === 'subscription',
  )

const httpLink = new HttpLink({
  uri: 'http://localhost:55432/graphql',
  // credentials: 'omit'
});

const wsLink = new WebSocketLink({
  uri: 'ws://localhost:55432/graphql',
  options: {
    reconnect: true
  }
});

const link = ApolloLink.split(hasSubscriptionOperation, wsLink, httpLink);

const apolloClient = new ApolloClient({
  link,
  cache: new InMemoryCache()
  // uri: 'http://localhost:55432/graphql'
});

class App extends Component {

  constructor() {
    super();

    this.state = {
      bookId: 1
    };
  }

  searchBox

  getBook(e) {
    e.preventDefault();
    this.setState({ bookId: this.searchBox.value })
  }

  render() {
    const query = gql`query ($bookId:Int!){
                        book(id:$bookId){
                          title
                          authors{
                            name
                          }
                          description
                          imageUrl
                          publicationDate          
                        }
                      }`;
    const subscription = gql`subscription commentsForBook($bookId: Int!){
                                commentAddedForBook(bookId:$bookId){
                                  commentDetails
                                  rating
                                }
                            }`;
    const { bookId } = this.state;

    return (
      <ApolloProvider client={apolloClient}>
        <div className="App">
          <header className="App-header">
            <img src={logo} className="App-logo" alt="logo" />
            <h1 className="App-title">Welcome to React</h1>
          </header>
          <div className="grid-container">
            <form onSubmit={this.getBook.bind(this)}>
              <div className="input-group">
                <span className="input-group-label">Book ID</span>
                <input ref={c => this.searchBox = c} className="input-group-field" defaultValue={bookId} type="number" />
                <div className="input-group-button">
                  <button type="submit" className="button success" ><i className="fas fa-search"></i></button>
                </div>
              </div>
            </form>
          </div>
          <Query query={query} variables={{ bookId }}>
            {
              ({ loading, error, data }) => {
                if (loading) return <p>Loading...</p>;
                if (error) return <p>Error :(</p>;
                if (!data.book) return <p>No book was found!</p>;

                const { title, imageUrl, description, authors, publicationDate } = data.book;
                return <div className="grid-container full">
                  <div className="grid-x grid-padding-x">
                    <div className="cell large-7 grid-x ">
                      <div className="cell large-3">
                        <div className="thumbnail">
                          <img alt={`${title} cover`} src={imageUrl} />
                        </div>
                      </div>
                      <div className="cell large-6 large-offset-1">
                        <h3>{title}</h3>
                        <h4 className="subheader"><sup>{publicationDate}</sup></h4>
                        <dl>
                          <dt>Author(s)</dt>
                          {authors.map(({ name }) => <dd key={name}>{name}</dd>)}
                        </dl>
                      </div>
                      <div className="cell large-11">
                        <p dangerouslySetInnerHTML={{ __html: description }}></p>
                      </div>
                    </div>
                    <div className="cell large-5">
                      <h5>Comments</h5>

                      <div className="callout">
                      </div>
                      <Subscription subscription={subscription} variables={{ bookId }}>
                        {
                          ({ loading, error, data }) => {
                            console.log(loading, error, data)
                            return <div className="callout">

                            </div>
                          }
                        }</Subscription>
                    </div>
                  </div>
                </div>
              }
            }
          </Query>
        </div>
      </ApolloProvider>
    );
  }
}

export default App;
