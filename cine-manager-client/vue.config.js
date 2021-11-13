module.exports = {
  transpileDependencies: [
    'vuetify'
  ],
  devServer: {
    // host: 'localhost'
    proxy: 'http://localhost:8080'
  }
}
