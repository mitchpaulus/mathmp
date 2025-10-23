
# References

<https://devblogs.microsoft.com/math-in-office/officemath/>

# N-ary experiments for Word

```
# WORKS
<math display="block" xmlns="http://www.w3.org/1998/Math/MathML">
  <munderover>
    <mo>∑</mo>
    <mrow><mi>i</mi><mo>=</mo><mn>1</mn></mrow>
    <mi>n</mi>
  </munderover>
  <mrow><msup><mi>a</mi><mi>i</mi></msup></mrow>
</math>

# Removing 'display="block"' works
<math xmlns="http://www.w3.org/1998/Math/MathML">
  <munderover>
    <mo>∑</mo>
    <mrow><mi>i</mi><mo>=</mo><mn>1</mn></mrow>
    <mi>n</mi>
  </munderover>
  <mrow><msup><mi>a</mi><mi>i</mi></msup></mrow>
</math>


# WORKS (Removed msup, just mi element)
<math xmlns="http://www.w3.org/1998/Math/MathML">
  <munderover>
    <mo>∑</mo>
    <mrow><mi>i</mi><mo>=</mo><mn>1</mn></mrow>
    <mi>n</mi>
  </munderover>
  <mrow><mi>a</mi></mrow>
</math>


# WORKS (Add mstyle with displaystyle="true")
<math xmlns="http://www.w3.org/1998/Math/MathML">
<mstyle displaystyle="true">
  <munderover>
    <mo>∑</mo>
    <mrow><mi>i</mi><mo>=</mo><mn>1</mn></mrow>
    <mi>n</mi>
  </munderover>
  <mrow><mi>a</mi></mrow>
</mstyle>
</math>

# DOES NOT WORK (wrapping munderover in mrow), operand doesn't grab
# https://devblogs.microsoft.com/math-in-office/officemath is wrong then in table
<math xmlns="http://www.w3.org/1998/Math/MathML">
<mstyle displaystyle="true">
  <mrow>
  <munderover>
    <mo>∑</mo>
    <mrow><mi>i</mi><mo>=</mo><mn>1</mn></mrow>
    <mi>n</mi>
  </munderover>
  </mrow>
  <mrow><mi>a</mi></mrow>
</mstyle>
</math>


# DOES NOT WORK (Removing mrow after)
<math xmlns="http://www.w3.org/1998/Math/MathML">
<mstyle displaystyle="true">
  <munderover>
    <mo>∑</mo>
    <mrow><mi>i</mi><mo>=</mo><mn>1</mn></mrow>
    <mi>n</mi>
  </munderover>
  <mi>a</mi><mi>b</mi>
</mstyle>
</math>

```
