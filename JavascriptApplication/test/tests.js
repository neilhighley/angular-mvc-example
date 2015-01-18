describe("ProofInstall", function () {
    var fncTest;
    beforeEach(function() {
        fncTest = new TestClass();
    });
    
    it("returns the sum of two numbers", function () {
       var expected = 3;
       var num1 = 1;
       var num2 = 2;
       expect(fncTest.returnSum(num1, num2)).toBe(expected);
    });
});
