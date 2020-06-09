export default {
  truncateString(str, length) {
    if (str != null) {
      if (str.length <= length) {
        return str
      }
      return str.slice(0, length)
    }

    return str
  }
}
