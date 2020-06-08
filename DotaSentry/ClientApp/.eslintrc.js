module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: [
    'plugin:vue/recommended',
    '@vue/airbnb',
  ],
  rules: {
    'no-console': process.env.NODE_ENV === 'production' ? 'error' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'error' : 'off',

    // airbnb base overrides
    'comma-dangle': ['error', 'never'], // trailing commas are unusual
    eqeqeq: 'off', // too strict, == is ok almost in all cases
    'linebreak-style': 'off', // lf doesn't work in vs, git autocrlf=true handles this
    'no-param-reassign': ['error', { props: false }], // modifying props is ok, especially in reduce
    semi: ['error', 'never'], // you don't need semis

    // temp platform fixes
    'func-names': 'off'
  },
  parserOptions: {
    parser: 'babel-eslint',
  },
};
